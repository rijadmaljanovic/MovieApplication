let _webAPIBaseURL = 'https://localhost:44388';
let movieURL = `${_webAPIBaseURL}/api/Movie`;
let authURL = `${_webAPIBaseURL}/api/Auth`;

export const environment = {
  production: true,

  webAPIBaseURL: _webAPIBaseURL,

  // MOVIE URLs
  moviesURL: `${movieURL}`,
  rateMovieByIdURL: `${movieURL}/rate`,

  // AUTH URLs
  loginURL: `${authURL}/login`,

  noPhotoPath: 'assets/no-photo.png',
  loaderGifPath:'assets/loading.gif',
  noResultsPhoto:'assets/no-results.png'

};