import { IArticle } from "./IArticle";

export interface IResponseArticle{
    articlesData: IArticle[];
    count : number;
    data : IArticle[];
    status : string;
}