import { patchState, signalStore, withHooks, withMethods } from '@ngrx/signals';
import { addEntities, addEntity, withEntities } from '@ngrx/signals/entities';
import { ResourceListItem, ResourceListItemCreateModel } from '../types';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { mergeMap, pipe, switchMap, tap } from 'rxjs';
import { ResourceDataService } from './resource-data.service';
import { inject } from '@angular/core';

export const ResourceStore = signalStore(
  withEntities<ResourceListItem>(),
  withMethods((store) => {
    const service = inject(ResourceDataService);
    return {
      add: rxMethod<ResourceListItemCreateModel>(
        pipe(
          mergeMap((item) =>
            service
              .addResource(item)
              .pipe(tap((r) => patchState(store, addEntity(r)))),
          ),
        ),
      ),
      _load: rxMethod<void>(
        pipe(
          switchMap(() =>
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
      store._load();
    },
  }),
);
