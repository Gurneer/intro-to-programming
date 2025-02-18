import { Routes } from '@angular/router';
import { ResourcesComponent } from './resources.component';
import { CreateComponent } from './components/create.component';
import { ListComponent } from './components/list.component';
export const RESOURCES_ROUTES: Routes = [
  {
    path: '',
    component: ResourcesComponent,
    children: [
      {
        path: 'create',
        component: CreateComponent,
      },
      {
        path: 'list',
        component: ListComponent,
      },
      {
        path: '**',
        redirectTo: 'list',
      },
    ],
  },
];
