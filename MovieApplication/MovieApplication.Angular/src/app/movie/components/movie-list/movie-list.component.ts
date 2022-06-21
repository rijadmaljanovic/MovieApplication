import { Component, Injector, Input, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject, debounceTime, switchMap, takeUntil, finalize } from 'rxjs';
import { AppConstants } from 'src/app/core/common/app-constants';
import { BaseComponent } from 'src/app/core/common/base.component';
import { MovieModel, SearchModel } from 'src/app/core/models/data-models';
import { MovieService } from 'src/app/core/services/data-services/movie.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.css']
})
export class MovieListComponent extends BaseComponent implements OnInit {

  noResult=environment.noResultsPhoto;
  movies: Array<MovieModel> = new Array<MovieModel>();
  pageNumber:number=1;
  search: SearchModel=new SearchModel;
  canLoadMore: boolean = true;
  searchString$: BehaviorSubject<string> = new BehaviorSubject<string>('');
  searchString: string = '';

  @Input() showOnlyMovies: boolean;

  constructor(injector:Injector, private movieService:MovieService, private toastr: ToastrService) {
    super(injector);
    this.showLoading();
    
  }

  ngOnInit() {
   
    this.searchString$.pipe(takeUntil(this.unsubscribe$),
                            debounceTime(300),
                            switchMap(searchString=>{
                            
                              this.showLoading();

                              this.searchString=searchString;
                              this.pageNumber=1;
                              this.regularSearch();

                              return this.movieService.getAllMovies(this.pageNumber,!this.showOnlyMovies,this.search)
                              .pipe(finalize(()=>this.hiddeLoading()));}))
                              .subscribe(
                                (res) => {
                                  this.handleLoadedMovies(res);
                                }
                              );

  }
  handleLoadedMovies(movies:Array<MovieModel>){
    if (movies != null) {
      this.movies = movies;
      this.canLoadMore = this.movies.length % 10 == 0;
    }
    else
      this.movies = new Array<MovieModel>();
  }

  loadMore() {
    this.pageNumber++;
    this.showLoading();

    this.movieService.getAllMovies(this.pageNumber, !this.showOnlyMovies, this.search)
                      .pipe(finalize(()=>this.hiddeLoading()))
                      .subscribe((res) => {
                                if (!res) {
                                  this.canLoadMore = false;
                                  return;
                                }
                                this.movies.push(...res);
                                this.canLoadMore = this.movies.length % 10 == 0;
                              },
                              (err) => { 
                              this.toastr.error(AppConstants.error_user_message);
                              });

  }

  onSearchKeyUp(value: string) {
    
    this.searchString$.next(value);
  }
  
  regularSearch() {

    this.search={value:this.searchString}
  }
}
