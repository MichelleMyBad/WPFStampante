# WPFStampante
Esercizio WPF che si occupa di emulare una stampante persistente. <br><br>

<b>UML</b> <br><br>
<img src="https://github.com/MichelleMyBad/WPFStampante/assets/127590227/60d17ba5-4133-48fc-92e4-e63b81f58442">
<br><br>


<b>Interfaccia grafica</b> <br>
<img src = "https://github.com/MichelleMyBad/WPFStampante/assets/127590227/f7af4535-3cd9-48a5-8cc1-f3bdefee96b6">
<br><br>

<b>Inchiostri</b> <br>
<img src="https://github.com/MichelleMyBad/WPFStampante/assets/127590227/bfd6c680-b681-4c3d-a82c-e66662fdfac1"><br>
La sezione dedicata agli inchiostri permette di ricaricarli tramite pulsante apposito e di vedere il loro livello di riempimento prima e dopo ogni stampa.
<br><br>

<b>Fogli</b><br>
<img src="https://github.com/MichelleMyBad/WPFStampante/assets/127590227/3f0958f2-f47b-4085-a9b2-baa7f29cc51c"><br>
La sezione dedicata ai fogli permette di osservare di quanti fogli si dispone e, in caso necessario, di ricaricare il serbatoio : basterà inserire i fogli che si desiderano inserire nella sezione destra, in caso si inserisca un numero di fogli maggiore di quanti ne possa tenere il serbatoio quelli in eccesso rimarranno nella sezione precedentemente citata.<br>
Esempio:<br>
<img src="https://github.com/MichelleMyBad/WPFStampante/assets/127590227/787ad060-0cdb-43e5-9fa2-bbf7f025dbc9" width="500">
<img src="https://github.com/MichelleMyBad/WPFStampante/assets/127590227/945a8613-61ee-43f6-84ce-8e4e7d036d51" width="500">
<br><br>

<b>Creazione pagina</b><br>
<img src="https://github.com/MichelleMyBad/WPFStampante/assets/127590227/4de1da86-bdaa-4daa-8c89-261df35e3e34"><br>
Per la creazione della pagina è possibile scegliere un valore da 0 a 3 manualmente, randomicamente o generare randomicamente l'intera pagina.
<br><br>

<b>Stampa</b><br>
<img src="https://github.com/MichelleMyBad/WPFStampante/assets/127590227/bbe43679-2d06-4797-b7ad-b161c0108aaf"><br>
Troviamo infine il pulsante di stampa, che, una volta premuto, simulerà una stamba, andando quindi a rimuovere  dai serbatoi dei diversi colori quanto indicato nella sezione precedente.<br>
Esempio:<br>
<img src="https://github.com/MichelleMyBad/WPFStampante/assets/127590227/c8fa9ba0-d70e-4d0a-9516-20cfddd29dc0" width="500">
<img src="https://github.com/MichelleMyBad/WPFStampante/assets/127590227/024d0e71-72eb-4711-ab91-dcffb1f1db4d" width="500">
<br><br>

<b>Persistenza della stampante</b><br>
Con "persistenza" si intende il mantenimento dello stato della stampante alla chiusura dell'applicazione. Il programma salverà lo stato dei diversi serbatoi e impostazioni della pagina in un file csv, che utilizzerà poi per ricaricarli una volta riaperta.


