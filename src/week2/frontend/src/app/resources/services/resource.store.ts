import {
  patchState,
  signalStore,
  withComputed,
  withHooks,
  withMethods,
  withState,
} from '@ngrx/signals';
import { addEntities, addEntity, withEntities } from '@ngrx/signals/entities';
import { ResourceListItem, ResourceListItemCreateModel } from '../types';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { mergeMap, pipe, switchMap, tap } from 'rxjs';
import { ResourceDataService } from './resource-data.service';
import { computed, inject } from '@angular/core';
import { withDevtools } from '@angular-architects/ngrx-toolkit';

// Higher-Ordered Function
export const ResourceStore = signalStore(
  withDevtools('resources'),
  withState<{ filteredBy: string | null }>({
    filteredBy: null,
  }),
  withEntities<ResourceListItem>(),
  withComputed((store) => {
    return {
      filteredResourceList: computed(() => {
        const filteredBy = store.filteredBy();
        if (filteredBy === null) {
          return store.entities();
        }
        return store.entities().filter((r) => r.tags.includes(filteredBy));
      }),
    };
  }),
  withMethods((store) => {
    const service = inject(ResourceDataService);
    return {
      setFilteredBy: (filteredBy: string | null) =>
        patchState(store, { filteredBy }),
      add: rxMethod<ResourceListItemCreateModel>(
        pipe(
          mergeMap(
            (
              item, // mergeMap - don't cancel "inflight" requests, I need the results of each of these calls.
            ) =>
              service
                .addResource(item)
                .pipe(tap((r) => patchState(store, addEntity(r)))),
          ),
        ),
      ),
      load: rxMethod<void>(
        pipe(
          switchMap(() =>
            // switchMap - cancel "inflight" requests, I only care about the latest one.
            service
              .getResource()
              .pipe(tap((r) => patchState(store, addEntities(r)))),
          ),
        ),
      ),
    };
  }),
  withHooks({
    onInit(store) {
      store.load();
    },
  }),
);
