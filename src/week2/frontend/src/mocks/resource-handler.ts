import { http, delay, HttpResponse } from 'msw';
import { ResourceListItem } from '../app/resources/types';

const FAKE_DATA: ResourceListItem[] = [
  {
    id: '1',
    title: 'Hypertheory Applied Angular Materials',
    description: 'Class Materials for Applied Angular',
    link: 'https://applied-angular.hypertheory.com',
    linkText: 'Hypertheory.com',
    createdBy: 'bob@aol.com',
    createdOn: '2025-02-18T17:27:32.084Z',
    tags: ['Angular', 'TypeScript', 'Training'],
  },
  {
    id: '2',
    title: 'NGRX',
    description: 'NGRX Family of Fine Angular Libraries',
    link: 'https://ngrx.io',
    linkText: 'NGRX.io',
    createdBy: 'sue@aol.com',
    createdOn: '2025-02-18T17:27:32.084Z',
    tags: ['Angular', 'TypeScript', 'Training', 'State', 'Signals', 'Redux'],
  },
];
export const ResourceHandlers = [
  //   http.get('http://localhost:1338/resources', async () => {
  //     await delay(3000);
  //     return HttpResponse.json(FAKE_DATA);
  //   }),
];
