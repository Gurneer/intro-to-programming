import {
  Component,
  ChangeDetectionStrategy,
  signal,
  inject,
} from '@angular/core';
import { ResourceStore } from '../services/resource.store';

@Component({
  selector: 'app-resource-filter',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [],
  template: `
    <div>
      <select (change)="changeTheFilter($event)" class="input input-bordered">
        @for (tag of tags(); track tag) {
          <option value="{{ tag }}">{{ tag }}</option>
        }
      </select>
    </div>
  `,
  styles: ``,
})
export class FilterComponent {
  tags = signal(['angular', 'k8s', 'dotnet']);
  store = inject(ResourceStore);
  changeTheFilter(event: any): void {
    // big old code smell here, yo.
    this.store.setFilteredBy(event.target.value);
  }
}
