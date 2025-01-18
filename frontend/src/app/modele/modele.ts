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

export interface Admin {
    id : number,
    email : string;
}

export interface Application {
    id : number;
    date : Date;
    message : string,
    status : string,
    jobId : number
    jobTitle : string;
}

export interface Company {
    id : number, 
    name: string, 
    email: string,
    description : string,
    location : string;
}

export interface Competencies {
    id : number,
    name: string;
}

export interface Experiences {
    id: number, 
    companyName : string,
    title : string,
    startDate : Date,
    endDate : Date,
    description : string,
}

export interface Formations {
    id : number,
    institution : string, 
    startDate : Date, 
    endDate : Date, 
    description : string;
}

export interface UserCompetencies {
    userId : Users["id"],
    competencyId : Competencies["id"], 
    competencyName : Competencies["name"];
}

export interface Users{
    id : number, 
    firstName : string,
    familyName : string,
    email : string,
    phone : string, 
    description : string,
    city : string,
    competencies : UserCompetencies,
    formations : Formations,
    experiences : Experiences;
}