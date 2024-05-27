import { Component, OnInit } from '@angular/core';
import { Perfil } from '@app/_models';
import { RetornoApi } from '@app/_models/retornoapi';
import { PerfilService } from '@app/_services/perfil.service';

@Component({
  selector: 'app-lista-perfil',
  templateUrl: './lista-perfil.component.html'
})
export class ListaPerfilComponent implements OnInit {

  searchText = "";
  perfis: Array<Perfil> | undefined;
  perfisOrigem: Array<Perfil> | undefined;

  constructor(
    private perfilService: PerfilService,) { }

  ngOnInit(): void {    

    this.perfilService.listar()
    .subscribe((dados : RetornoApi) => {
      if(dados.resultado){
        this.perfis = dados.resultado as Perfil[] ;
        this.perfisOrigem = dados.resultado as Perfil[] ;
      }
    
    });

    
  }
  
  Search(){
    // alert(this.searchText)
     if(this.searchText!== ""){
       let searchValue = this.searchText.toLocaleLowerCase();      
       this.perfis = this.perfisOrigem?.filter((contact:any) =>{
         return contact.nome.toLocaleLowerCase().match(searchValue );       
             });             
           }else{
            this.perfis = this.perfisOrigem
           }
       }


}

