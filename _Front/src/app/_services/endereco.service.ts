import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '@environments/environment';
import { Perfil, User, UserLogin } from '@app/_models';
import { RetornoApi } from '@app/_models/retornoapi';
import { EnderecoModel } from '@app/_models/enderecomodel';
import { AccountService } from './account.service';
import * as saveAs from 'file-saver';
@Injectable({ providedIn: 'root' })
export class EnderecoService {


    constructor(
      private accountService: AccountService,
        private router: Router,
        private http: HttpClient
    ) {

    }


    salvarEndereco(Endereco: EnderecoModel) {

      let token = this.accountService.userValue?.token;

      const headers = new HttpHeaders({
        'Authorization': `Bearer ${token}`
      });
        return this.http.post(`${environment.apiUrl}Endereco/Salvar`, Endereco,  { headers });
    }

    RecuperarArquivoCSVEnderecos(NomeArquivo: string) {
      let token = this.accountService.userValue?.token;

      const headers = new HttpHeaders({
        'Authorization': `Bearer ${token}`
      });

      const url =`${environment.apiUrl}Endereco/RecuperarArquivoCSVEnderecos/`+ NomeArquivo;
      this.http.get(url, {  headers, responseType: 'blob' })
      .subscribe((response: Blob) => {
        saveAs(response, 'nome_do_arquivo.csv');
      }, error => {
        console.error('Erro ao baixar o arquivo:', error);
      });
  }
  ObterDadosAtravesCep(Cep: string) {
    let token = this.accountService.userValue?.token;

      const headers = new HttpHeaders({
        'Authorization': `Bearer ${token}`
      });
    return this.http.get(`${environment.apiUrl}Endereco/ObterDadosAtravesCep?cep=`+ Cep,  { headers });
}

  listar() {
    let token = this.accountService.userValue?.token;

      const headers = new HttpHeaders({
        'Authorization': `Bearer ${token}`
      });
        return this.http.get<RetornoApi>(`${environment.apiUrl}Endereco/Lista`,  { headers });
    }

    obterPorId(id:number) {
      let token = this.accountService.userValue?.token;

        const headers = new HttpHeaders({
          'Authorization': `Bearer ${token}`
        });
          return this.http.get<RetornoApi>(`${environment.apiUrl}Endereco/Carregar?Id=`+id,  { headers });
      }


      Deleta(id:number) {
      let token = this.accountService.userValue?.token;

        const headers = new HttpHeaders({
          'Authorization': `Bearer ${token}`
        });
          return this.http.delete<RetornoApi>(`${environment.apiUrl}Endereco/Deleta?Id=`+id,  { headers });
      }
}
