import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, debounceTime, distinctUntilChanged, map, Observable, of, Subject, switchMap, tap, throwError } from "rxjs";
import { Article, IArticle } from "../models/IArticle";
import { IResponseArticle } from "../models/IResponseArticle";

@Injectable({
    providedIn: 'root'
  })
  export class ArticleApiService{
    public basURL : string = "https://localhost:7014/api/articles/";
    formData: Article = new Article();
    private type = new Subject<string>();
    typeChanged = this.type.asObservable();
    currentType: string = '';
    constructor(public http : HttpClient) { }

    getStock() : Observable<IResponseArticle>{
        return this.http.get<IResponseArticle>(this.basURL+ "allArticles").pipe(
            tap((data: any) => console.log('All', JSON.stringify(data))),
            catchError(this.handleError)
        );
    }
    postArticle(data: any){
        return this.http.post(this.basURL + "Add", data);
      }
      postArticles(data : any){
        return this.http.post<any>(this.basURL,data)
        .pipe(
            tap((data: any) => console.log('All', JSON.stringify(data))),
            catchError(this.handleError)
        );
    }
     // Add error handle
     private handleError(err: HttpErrorResponse) {
        let errorMessage = '';
        if(err.error instanceof ErrorEvent){
            errorMessage = `An error occured : ${err.error.message}`;
        }
        else{
            errorMessage = `Server returned code: ${err.status}, error message is:${err.message}`;

        }
        console.error(errorMessage);
        return throwError(errorMessage);
    }
    addNew(data: Article): Observable<Article> {
        debugger
        return this.http.post<Article>(this.basURL + "Add", data);
      }
    update(data: Article): Observable<Article> {
        debugger
        return this.http.put<Article>(this.basURL + data.reference, data);
      }

    delete(reference: string): Observable<IArticle> {
        return this.http.delete<any>(this.basURL+ reference)
    }
    DeleteArticle(reference: string){
        return this.http.delete<any>(this.basURL+ reference)
        .pipe(map((res:any)=>{
          return res;
        }))
      }
      changeType(newType: string) {
        this.type.next(newType);
      }
  }