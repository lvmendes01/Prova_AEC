import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EnderecoModel } from '@app/_models/enderecomodel';
import { RetornoApi } from '@app/_models/retornoapi';
import { EnderecoService } from '@app/_services/endereco.service';
@Component({
  selector: 'app-lista-Endereco',
  templateUrl: './lista-Endereco.component.html'
})
export class ListaEnderecoComponent implements OnInit {
  EnderecosOrigem: Array<EnderecoModel> | undefined;
  Enderecos: Array<EnderecoModel> | undefined;
  searchText = "";

  constructor(
    private router: Router,
    private enderecoService: EnderecoService,)

    { }
  ngOnInit(): void {
    this.enderecoService.listar()
    .subscribe((dados : RetornoApi) => {
      if(dados.resultado){
        this.Enderecos = dados.resultado as EnderecoModel[] ;
        this.EnderecosOrigem = dados.resultado as EnderecoModel[] ;
      }
    });
  }

  Search(){
    // alert(this.searchText)
     if(this.searchText!== ""){
       let searchValue = this.searchText.toLocaleLowerCase();
       this.Enderecos = this.EnderecosOrigem?.filter((contact:any) =>{
         return contact.logradouro.toLocaleLowerCase().match(searchValue );
             });
           }else{
            this.Enderecos = this.EnderecosOrigem
           }
       }


       btnCadastro(){
        this.router.navigateByUrl('/enderecocadastro');
       }
       btnBaixar(){
        this.enderecoService.RecuperarArquivoCSVEnderecos("Teste");

       }
}

