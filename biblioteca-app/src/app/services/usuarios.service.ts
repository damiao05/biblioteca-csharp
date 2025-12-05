import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class UsuariosService {

    private apiUrl = '/api/usuarios';

    constructor(private http: HttpClient) {}

    cadastrarUsuario(dadosUsuario: any): Observable<any> {
        return this.http.post(this.apiUrl, dadosUsuario);
    }

}