import { Injectable, Injector } from '@angular/core';
import { BaseService } from '../../common/base.service';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { SearchModel } from '../../models/data-models';
import { MovieRequestModel } from '../../models/data-models';

@Injectable({
  providedIn: 'root'
})
export class MovieService extends BaseService {

  constructor(injector:Injector) {
    super(injector);
  }

  getAllMovies(page:number,tvShow:boolean,search:SearchModel):Observable<any>{
    let url=`${environment.moviesURL}`;
    let moviesRequestModel:MovieRequestModel={page:page,tvShow:tvShow,search:search};
    return this.post(url,moviesRequestModel);
  }

  getById(movieId:number):Observable<any>{
    let url=`${environment.moviesURL}/${movieId}`;
    return this.get(url);
  }
  
  rateMovie(movieId:number,rating:number){
    let url=`${environment.rateMovieByIdURL}/${movieId}`;
    return this.post(url,rating);
  }
}
