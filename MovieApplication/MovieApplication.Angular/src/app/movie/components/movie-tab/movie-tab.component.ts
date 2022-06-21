import { Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from 'src/app/core/common/base.component';

@Component({
  selector: 'app-movie-tvshow-tab',
  templateUrl: './movie-tab.component.html',
  styleUrls: ['./movie-tab.component.css']
})
export class MovieTabComponent extends BaseComponent implements OnInit {

  showMovies:boolean=true;

  constructor(injector:Injector) {
    super(injector);
    
  }

  ngOnInit(){
    
  }

  toggleShowMovie(show:boolean) {
    this.showMovies=show;
  }

}
