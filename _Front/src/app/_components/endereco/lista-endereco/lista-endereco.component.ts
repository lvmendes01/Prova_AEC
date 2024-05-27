import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EnderecoModel } from '@app/_models/enderecomodel';
import { RetornoApi } from '@app/_models/retornoapi';
import { EnderecoService } from '@app/_services/endereco.service';
import Swal from 'sweetalert2';

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
       btnEditar(id: number){
        this.router.navigateByUrl('/enderecocadastro/'+ id);
       }


        btnRemover(id: number){

          Swal.fire({
            title: "Remover?",
            text: "Deseja remover!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Sim"
          }).then((result) => {
            if (result.isConfirmed) {

              this.enderecoService.Deleta(id)
              .subscribe((dados : RetornoApi) => {
                if(dados.resultado){
                  this.EnderecosOrigem = (this.EnderecosOrigem ?? []).filter(item => item.id !== id); // Atualize a lista de itens localmente
                  this.Enderecos= (this.Enderecos ?? []).filter(item => item.id !== id); // Atualize a lista de itens localmente

                }
              });

            }
          });

         }

       }



