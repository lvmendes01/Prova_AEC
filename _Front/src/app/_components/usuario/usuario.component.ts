import { Component, OnInit } from '@angular/core';
import { Perfil, Permiss } from '@app/_models';
import { UsuarioModel, UsuarioModelSalvar } from '@app/_models/usuariomodel';
import { PerfilService } from '@app/_services/perfil.service';
import { UsuarioService } from '@app/_services/usuario.service';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html'
})
export class UsuarioComponent implements OnInit {

  usuario= new UsuarioModel();
  perfis = new Array<Perfil>();
  perfil = new Perfil();
  loading = false;
  submitted = false;
  constructor(
    private perfilService: PerfilService,
    private usuarioService: UsuarioService,) { }

  ngOnInit(): void {

    this.perfilService.listar().subscribe(
      (dados)=>{
this.perfis = dados.resultado as Array<Perfil>;
      }
    );
  }

  Salvar(){

  
    let usuario = new UsuarioModelSalvar;
    usuario.login = this.usuario.login;
    usuario.perfil =this.perfil.id;
    usuario.nome = this.usuario.nome;
    this.usuarioService.salvarUsuario(usuario)
    .subscribe((dados)=>{

      if(dados != null){
        
      }

    })
    


  }
}
