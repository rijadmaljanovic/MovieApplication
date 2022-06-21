import { Location } from '@angular/common';
import { Component, Injector, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { finalize, takeUntil } from 'rxjs';
import { AppConstants } from 'src/app/core/common/app-constants';
import { BaseComponent } from 'src/app/core/common/base.component';
import { MovieDetailsModel } from 'src/app/core/models/data-models';
import { MovieService } from 'src/app/core/services/data-services/movie.service';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent extends BaseComponent implements OnInit {

  movie:MovieDetailsModel=new MovieDetailsModel;
  isDetail:boolean=true;

  @Input() movieID:number;

  constructor(injector:Injector,private movieService:MovieService, private route:ActivatedRoute, private toastr:ToastrService, private location:Location) {
   super(injector);

 }

  ngOnInit(): void {
    let movieId=this.route.snapshot.params['id'];
    let movideModalId=this.movieID;
    
    if(!movideModalId)
    {
      this.getMovie(movieId);
      this.isDetail=true;
      return;
    }
    this.getMovie(movideModalId);
    this.isDetail=false;
  }

  getMovie(movieId:number){
    if(movieId==undefined)
      return;
      
    this.movieService.getById(movieId)
    .pipe(finalize(()=>this.hiddeLoading()))
    .subscribe(
    (res)=>{
      this.movie=res;
    },
    (err)=>{
      this.toastr.error(AppConstants.error_user_message);
    });
  }

  backClicked() {
    this.location.back();
    //window.history.back()
  }
}
