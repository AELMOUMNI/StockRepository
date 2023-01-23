import { Pipe, PipeTransform } from "@angular/core";
import { IArticle } from "../core/models/IArticle";

@Pipe({name:'searchFilter'})

export class SearchPipe implements PipeTransform {
    transform(articles: IArticle[], searchText: string) : IArticle[]{
        return articles.filter(article=> article.reference.toLocaleLowerCase().includes(
            searchText.toLocaleLowerCase()
        ));
    }
}