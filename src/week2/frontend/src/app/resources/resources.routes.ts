import { Routes } from '@angular/router';
import { ResourcesComponent } from './resources.component';
export const RESOURCES_ROUTES: Routes = [
  {
    path: '',
    component: ResourcesComponent,
    children: [],
  },
];
