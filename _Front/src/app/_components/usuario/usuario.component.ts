import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RetornoApi } from '@app/_models/retornoapi';
import {  UsuarioModelSalvar } from '@app/_models/usuariomodel';
import { AlertService } from '@app/_services';
import { UsuarioService } from '@app/_services/usuario.service';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html'
})
export class UsuarioComponent implements OnInit {

  usuario= new UsuarioModelSalvar();
  loading = false;
  submitted = false;
  constructor(
    private usuarioService: UsuarioService,
    private router: Router,
    private alertService: AlertService) { }

  ngOnInit(): void {


  }

  Salvar(){


    this.usuarioService.salvarUsuario(this.usuario)
    .subscribe((dados : RetornoApi) => {
      if(dados.resultado){


        this.alertService.success(dados.mensagem??"");
        this.router.navigateByUrl('/');
      }else{

        this.alertService.error(dados.mensagem??"");
      }
    });



  }
}
