import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { AuthGuard } from './shared/guards/auth.guard';
import { NotSavedGuard } from './shared/guards/not-saved.guard';
import { ValidIdGuard } from './shared/guards/valid-id.guard';
import { TripsComponent } from './trips/trips.component';
import { LoginComponent } from './public/login.component';
import { ReactPageComponent } from './react-page/react-page.component';
import { MychartComponent } from './component/mychart/mychart.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'about', component: AboutComponent },
  { path: 'react', component: ReactPageComponent },
  { path: 'chart', component: MychartComponent
  },
  {
    path: 'traveldetails',
    component: TripsComponent,
    canActivate: [ValidIdGuard, AuthGuard],
    canDeactivate: [NotSavedGuard],
    data: { redirectTo: 'traveldetails', claimType: 'canAccessTravelDetails' },
  },
  { path: 'login', component: LoginComponent },
];
