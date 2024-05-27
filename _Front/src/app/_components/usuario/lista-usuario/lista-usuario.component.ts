import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RetornoApi } from '@app/_models/retornoapi';
import { UsuarioModel } from '@app/_models/usuariomodel';
import { UsuarioService } from '@app/_services/usuario.service';

@Component({
  selector: 'app-lista-usuario',
  templateUrl: './lista-usuario.component.html'
})
export class ListaUsuarioComponent implements OnInit {
  usuariosOrigem: Array<UsuarioModel> | undefined;
  usuarios: Array<UsuarioModel> | undefined;
  searchText = "";

  constructor(
    private router: Router,
    private usuarioService: UsuarioService,) { }
  ngOnInit(): void {    
    this.usuarioService.listar()
    .subscribe((dados : RetornoApi) => {
      if(dados.resultado){
        this.usuarios = dados.resultado as UsuarioModel[] ;
        this.usuariosOrigem = dados.resultado as UsuarioModel[] ;
      }    
    });   
  }  

  Search(){
    // alert(this.searchText)
     if(this.searchText!== ""){
       let searchValue = this.searchText.toLocaleLowerCase();      
       this.usuarios = this.usuariosOrigem?.filter((contact:any) =>{
         return contact.nome.toLocaleLowerCase().match(searchValue );       
             });             
           }else{
            this.usuarios = this.usuariosOrigem
           }
       }


       btnCadastro(){
        this.router.navigateByUrl('/usuariocadastro');
       }
}

