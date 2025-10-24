import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MovieCardModel } from '../../shared/models/MovieCardModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class Movie {

  constructor(private http: HttpClient) {}
  //https://localhost:7025/api/Movies/top-grossing
  getTopGrossingMovies() : Observable<MovieCardModel[]> {
    return this.http.get<MovieCardModel[]>('https://localhost:7025/api/Movies/top-grossing');
  }

  getMovieDetails(id: number){ //int id

  }

  getMoviesByGenre(genreId: number){

  }
}

//getTopGrossingMovies()
