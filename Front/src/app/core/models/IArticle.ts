        export interface IArticle{
            id:string;
            reference : string;
            name : string;
            quantity : number;
            tva: number;
            ht: number;
            type: number;
            isTakeWay: boolean;
            ttc: number;
        }
        export class Article{
            reference: string = ''
            name: string = '';
            price: number = 10
            quantity: number = 0
            type: number = 0;
            isTakeWay: boolean = true;
        }