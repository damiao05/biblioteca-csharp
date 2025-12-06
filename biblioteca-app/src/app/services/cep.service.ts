import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class CepService {
    
    private viaCepUrl = 'https://viacep.com.br/ws/';

    constructor(private http: HttpClient) { }

    buscarEndereco(cep: string): Observable<any> {

        const cepLimpo = cep.replace(/\D/g, '');
        const url = `${this.viaCepUrl}${cepLimpo}/json/`;

        return this.http.get(url);

    }

}