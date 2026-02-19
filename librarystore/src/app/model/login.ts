export class Login {
    email:string;
    password:string;

constructor(email:string,password:string){
    this.email=email;
    this.password=password;
}

}

export class AuthResponseModel{
    id:string;
    email:string;
    userName:string;
    token:string

    constructor(id:string,email:string,userName:string,token:string) {
        this.id=id;
        this.email=email;
        this.userName=userName;
        this.token=token;
    }
}
