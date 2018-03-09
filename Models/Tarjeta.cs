using System;
using System.ComponentModel.DataAnnotations;

namespace CreditoWeb.Models
{
    public class Tarjeta
    {
        [Required(ErrorMessage = "El número de tarjeta es necesario.")]
        //[CreditCard] 
        public string TarjetaNumero { get; set; }
        public TipoTarjeta TipoTarjeta { get; set; }

        public bool Valida { get; set; }
     
        public Tarjeta(string tarjetaNumero)
        {
            this.TarjetaNumero = tarjetaNumero;
            Valida = esValida();
            TipoTarjeta = tipoDeTarjeta();            
        }


        /// Basado en el algoritmo de Luhn determinar si esta tarjeta es valida
        /// como estamos dentro de la clase de tarjeta tenemos acceso a la propiedad TarjetaNum 
        private bool esValida()
        {
            int mismos=0;
            int a=0;
            int conversion=0;
            int suma=0;
            
            for(int i=TarjetaNumero.Length-1;i>=0;i-=2){
                conversion=0;
                int x=(int)char.GetNumericValue(TarjetaNumero[i]);
                suma=suma+x;
                if(i-1>=0){
                      conversion=(int)char.GetNumericValue(TarjetaNumero[i-1]);}
               var xd=conversion*2;
                if(xd>9){xd=xd-9;}
                a=a+xd;
        }
            mismos=a+suma;
            return mismos%10==0;
                }


        /// Si la tarjeta es valida determinar de cuál tipo es VISA, MASTERCARD, AMERICANEXPRESS
        /// como estamos dentro de la clase de tarjeta tenemos acceso a la propiedad TarjetaNum 
        private TipoTarjeta tipoDeTarjeta()
        {
            var tipo=TipoTarjeta.NOVALIDA;
            if((TarjetaNumero[0]=='3'&& TarjetaNumero[1]=='4')||(TarjetaNumero[0]=='3'&& TarjetaNumero[1]=='7'))
            {
                tipo=TipoTarjeta.AMERICANEXPRESS;
            }
            if((TarjetaNumero[0]=='5'&& TarjetaNumero[1]=='1')||(TarjetaNumero[0]=='5'&& TarjetaNumero[1]=='2')||(TarjetaNumero[0]=='5'&& TarjetaNumero[1]=='3')||(TarjetaNumero[0]=='5'&& TarjetaNumero[1]=='4')||(TarjetaNumero[0]=='5'&& TarjetaNumero[1]=='5'))
            {
                tipo=TipoTarjeta.MASTERCARD;
            }
            if(TarjetaNumero[0]=='4')
            {
                tipo=TipoTarjeta.VISA;
            }
            return tipo;
        }



    }

    public enum TipoTarjeta
    {
        VISA,
        MASTERCARD,
        AMERICANEXPRESS,
        NOVALIDA


    }
}