export interface JobOffer {
    id : number;
    title : string;
    shortDescription : string;
    longDescription : string;
    contractType : string;
    creationDate : Date;
    location : string;
    companyId : number;
    companyName : string;
}
