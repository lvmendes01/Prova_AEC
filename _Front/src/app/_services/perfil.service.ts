import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '@environments/environment';
import { Perfil, User, UserLogin } from '@app/_models';
import { RetornoApi } from '@app/_models/retornoapi';

@Injectable({ providedIn: 'root' })
export class PerfilService {
  

    constructor(
        private router: Router,
        private http: HttpClient
    ) {
      
    }
    salvarPerfil(perfil: Perfil) {
        return this.http.post(`${environment.apiUrl}perfil/salvar`, perfil);
    }

    listar() {
        return this.http.get<RetornoApi>(`${environment.apiUrl}perfil/obterPerfil`);
    }


}