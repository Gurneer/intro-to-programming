import { HttpClient } from '@angular/common/http';
import { inject } from '@angular/core';
import { ResourceListItem, ResourceListItemCreateModel } from '../types';
import { environment } from '../../../environments/environment';
import { tagMaker } from './tagmaker';

export class ResourceDataService {
  private readonly URL = environment.apiUrl;

  private client = inject(HttpClient);

  getResource() {
    return this.client.get<ResourceListItem[]>(this.URL + 'resources');
  }

  addResource(item: ResourceListItemCreateModel) {
    const itemToSend = {
      ...item,
      tags: tagMaker(item.tags),
    };
    return this.client.post<ResourceListItem>(
      this.URL + 'resources',
      itemToSend,
    );
  }
}
