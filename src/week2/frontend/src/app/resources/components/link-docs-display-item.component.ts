import { Component, ChangeDetectionStrategy, input } from '@angular/core';
import { ResourceListItem } from '../types';
import { DatePipe } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-link-docs-display-item',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [DatePipe, RouterLink],
  template: `
    <div class="card bg-neutral text-neutral-content w-96">
      <div class="card-body items-center text-center">
        <h2 class="card-title">Documentation: {{ link().title }}</h2>
        <p>{{ link().description }}</p>
        <div class="card-actions justify-end">
          <a class="btn btn-link" [href]="link().link" target="_blank">{{
            link().linkText
          }}</a>
          <div>
            @for (tag of link().tags; track $index) {
              <div class="badge badge-secondary badge-outline hover:badge-lg">
                <a [routerLink]="['.']" [queryParams]="{ filter: tag }">{{
                  tag
                }}</a>
              </div>
            }
          </div>
          <div>
            <p>
              This was created by {{ link().createdBy }} on
              {{ link().createdOn | date }}
            </p>
          </div>
        </div>
      </div>
    </div>
  `,
  styles: ``,
})
export class LinkDocsDisplayItemComponent {
  link = input.required<ResourceListItem>();
}
