import { Categorie } from "./Categorie";

export interface PostCreateDto {
    UserId:number,
    Tittle:string, 
    Description:string,
    Route:string,
    Categories:Categorie[]
}