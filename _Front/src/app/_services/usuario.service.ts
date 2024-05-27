import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '@environments/environment';
import { Perfil, User, UserLogin } from '@app/_models';
import { RetornoApi } from '@app/_models/retornoapi';
import { UsuarioModel, UsuarioModelSalvar } from '@app/_models/usuariomodel';

@Injectable({ providedIn: 'root' })
export class UsuarioService {


    constructor(
        private router: Router,
        private http: HttpClient
    ) {

    }
    salvarUsuario(usuario: UsuarioModelSalvar) {
        return this.http.post(`${environment.apiUrl}Usuario/Salvar`, usuario);
    }

    listar() {
        return this.http.get<RetornoApi>(`${environment.apiUrl}Usuario/ListaUsuarios`);
    }


}
