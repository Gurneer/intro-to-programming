import {
  ChangeDetectionStrategy,
  Component,
  inject,
  resource,
} from '@angular/core';
import { LinkDocsDisplayItemComponent } from './link-docs-display-item.component';
import { ResourceStore } from '../services/resource.store';

@Component({
  selector: 'app-resources-list',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [LinkDocsDisplayItemComponent],
  template: `
    <div class="flex gap-4">
      @for (link of store.entities(); track link.id) {
        <app-link-docs-display-item [link]="link" />
      } @empty {
        <p>You don't have any resources! Add Some?</p>
      }
    </div>
  `,
  styles: ``,
})
export class ListComponent {
  // Rate my code!
  // What is "slime" here? The hard coded URL - this cannot abide. Not allowed to do that.
  // What design principal are we violating? - some service that does the API stuff for us.
  // What are the implications of this being in this component?
  store = inject(ResourceStore);
}
