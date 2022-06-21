export class MovieModel{
    id:number=0;
    movieTitle:string="";
    imagePath:string="";
    description:string="";
    releaseDate:string="";
    tvShow:boolean=false;
    avgRating:number=0;
    ratingByUser:number=0;
}

export class ActorModel{
    id:number=0;
    name:string="";
    imagePath:string="";
}

export class MovieDetailsModel{
    id:number=0;
    movieTitle:string="";
    imagePath:string="";
    description:string="";
    releaseDate:string="";
    tvShow:boolean=false;
    avgRating:number=0;
    ratingByUser:number=0;
    actors:Array<ActorModel>=new Array<ActorModel>();
}

export class LoginModel{
    username:string="";
    password:string="";
}

export class SearchModel{
    
    value:string="";
}

export class MovieRequestModel{
    page:number=1;
    tvShow:boolean=false;
    search:SearchModel=new SearchModel();
}