import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MovieDetailsComponent } from './components/movie-details/movie-details.component';
import { MovieHomeComponent } from './components/movie-home/movie-home.component';
import { MovieTabComponent } from './components/movie-tab/movie-tab.component';

const routes: Routes = [
  {
    path:"",
    component:MovieHomeComponent,
    children:[
      {path:"", component:MovieTabComponent},
      {path:"details/:id",component:MovieDetailsComponent},
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MovieRoutingModule { }
