import { Routes } from '@angular/router';
import { HomeComponent } from './components/home.component';

export const routes: Routes = [
  {
    path: 'dashboard',
    component: HomeComponent,
  },
  {
    path: 'banking',
    loadChildren: () =>
      import('./banking/banking.routes').then((r) => r.BANKING_ROUTES), // lazy loading, more later.
  },
  {
    path: 'resources',
    loadChildren: () =>
      import('./resources/resources.routes').then((r) => r.RESOURCES_ROUTES),
  },
  {
    path: '**', // catch all
    redirectTo: 'dashboard',
  },
];
