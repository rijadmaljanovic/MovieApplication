import { NgModule } from '@angular/core';

import { MovieRoutingModule } from './movie-routing.module';
import { MovieHomeComponent } from './components/movie-home/movie-home.component';
import { MovieDetailsComponent } from './components/movie-details/movie-details.component';
import { MovieTabComponent } from './components/movie-tab/movie-tab.component';
import { MovieListComponent } from './components/movie-list/movie-list.component';
import { SharedModule } from '../shared/shared.module';
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { MovieCardComponent } from './components/movie-card/movie-card.component';
import { MovieModalComponent } from './components/movie-modal/movie-modal.component';

@NgModule({
  declarations: [MovieHomeComponent, MovieDetailsComponent, MovieTabComponent, MovieListComponent, MovieCardComponent, MovieModalComponent],
  imports: [
    SharedModule,
    MovieRoutingModule,
    NgbModule, 
  ]
})
export class MovieModule { }
