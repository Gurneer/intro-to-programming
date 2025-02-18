import { HttpClient } from '@angular/common/http';
import { inject } from '@angular/core';
import { ResourceListItem, ResourceListItemCreateModel } from '../types';
import { environment } from '../../../environments/environment';
export class ResourceDataService {
  private readonly URL = environment.apiUrl;

  private client = inject(HttpClient);

  getResource() {
    return this.client.get<ResourceListItem[]>(this.URL + 'resources');
  }

  addResource(item: ResourceListItemCreateModel) {
    // item.tags = string
    // item.tags = string[] "dog cat mouse mouse" -> ["dog", "cat", "mouse"]
    return this.client.post<ResourceListItem>(this.URL + 'resources', item);
  }
}
