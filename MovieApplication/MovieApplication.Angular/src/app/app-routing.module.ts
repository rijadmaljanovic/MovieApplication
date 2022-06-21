import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuardService } from './core/guards/auth-guard.service';
import { LoginRouteGuardService } from './core/guards/login-route-guard.service';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
    {
      path: 'movie',
      loadChildren: () => import('./movie/movie.module').then(mod => mod.MovieModule),
      canActivate:[AuthGuardService]
    },
    {
      path:'login',
      component:LoginComponent,
      canActivate:[LoginRouteGuardService]
    },
{
  path:'**',
  redirectTo:'/movie',
  pathMatch:'full'
},
  {
    path:'',
    redirectTo:'/movie',
    pathMatch:'full'
  },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }