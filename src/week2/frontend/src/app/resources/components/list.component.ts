import { Component, ChangeDetectionStrategy, signal } from '@angular/core';
import { ResourceListItem } from '../types';
import { LinkDocsDisplayItemComponent } from './link-docs-display-item.component';

@Component({
  selector: 'app-resources-list',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [LinkDocsDisplayItemComponent],
  template: `
    <div class="flex gap-4">
      @for (link of links(); track link.id) {
        <app-link-docs-display-item [link]="link" />
      }
    </div>
  `,
  styles: ``,
})
export class ListComponent {
  links = signal<ResourceListItem[]>([
    {
      id: '1',
      title: 'Hypertheory Applied Angular Materials',
      description: 'Class Materials for Applied Angular',
      link: 'https://applied-angular.hypertheory.com',
      linkText: 'Hypertheory.com',
      tags: ['Angular', 'TypeScript', 'Training'],
    },
    {
      id: '2',
      title: 'NGRX',
      description: 'NGRX Family of Fine Angular Libraries',
      link: 'https://ngrx.io',
      linkText: 'NGRX.io',
      tags: ['Angular', 'TypeScript', 'Training', 'State', 'Signals', 'Redux'],
    },
  ]);
}
