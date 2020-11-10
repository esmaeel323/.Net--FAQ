import { Component } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { FAQs, IFAQs } from "./FAQ";
import { Question, IQuestion } from "./Question";
import { AvgangFAQ, IAvgangFAQ } from "./Avgang";


@Component({
    selector: "min-app",
    templateUrl: "Home.html"
})
export class Home {
    ShowSkjema: boolean;
    skjemaStatus: string;
    ShowFAQList: boolean;
    ShowAvgSTKFAQList: boolean;
    allFAQs: Array<FAQs>;
    ShowAnswerList: boolean;
    answer: Array<FAQs>;
    allAvgSTK: Array<AvgangFAQ>;
    skjema: FormGroup;
    laster: boolean;
    stem = 1;
    Registrert: boolean;
    Home: boolean;

    constructor(private _http: HttpClient, private fb: FormBuilder) {
        this.skjema = fb.group({
            id: [""],
            navn: [null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ\\-. ]{2,50}")])],
            epost: [null, Validators.compose([Validators.required, Validators.pattern("[A-Za-z0-9._-]+@[A-Za-z0-9.-_]+\.[A-Za-z.]{3,10}")])],
            question: [null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ.,? ]{2,100}")])],
        });
    }

    ngOnInit() {
        this.laster = true;
        this.hentAlleFAQs();
        this.hentAvgangFAQs();
        this.ShowSkjema = false;
        this.ShowFAQList = false;
        this.ShowAvgSTKFAQList = false;
        this.ShowAnswerList = false;
        this.Registrert = false;
        this.Home = true;
    }

    visFAQ() {
        this.ShowFAQList = !this.ShowFAQList;
        this.laster = this.laster;
        this.ShowAvgSTKFAQList = false;
        this.Home = false;
        this.ShowSkjema = false;
        this.ShowAnswerList = false;
        this.Registrert = false;
    }

    visAvgangFAQ() {
        this.ShowAvgSTKFAQList = !this.ShowAvgSTKFAQList;
        this.laster = this.laster;
        this.ShowSkjema = false;
        this.ShowFAQList = false;
        this.Home = false;
        this.ShowAnswerList = false;
        this.Registrert = false;
    }


    hentAlleFAQs() {
        this._http.get<IFAQs[]>("api/FAQ/")
            .subscribe(
                Question => {
                    this.allFAQs = Question;
                    console.log(this.allFAQs);
                    console.log("OK post-api/FAQ");

                },
                error => alert(error)
            );
    };



    hentAvgangFAQs() {
        this._http.get<IAvgangFAQ[]>("api/AvgangFAQ/")
            .subscribe(
                Question => {
                    this.allAvgSTK = Question;
                    console.log(this.allAvgSTK);
                    console.log("OK post-api/AvgangFAQ");

                },
                error => alert(error)
            );
    };

    hentSvar(id: number) {
        this._http.get<IFAQs[]>("api/FAQ/" + id)
            .subscribe(
                Question => {
                    this.answer = Question;
                    this.ShowAnswerList = true;


                    console.log("OK post-api/AvgangFAQ");

                },
                error => alert(error)
            );
    };



    vedSubmit() {
        if (this.skjemaStatus == "Registrer") {
            this.lagreFAQ();
            this.Registrert = true;
            this.Home = false;

        }

        else {
            alert("Feil i applikasjonen!");
        }
    }

    registrerFAQs() {

        this.skjema.setValue({
            id: "",
            navn: "",
            epost: "",
            question: ""


        });
        this.skjema.markAsPristine();
        this.ShowFAQList = false;
        this.ShowAvgSTKFAQList = false;
        this.skjemaStatus = "Registrer";
        this.ShowSkjema = true;
        

    }

    Tilbake() {

        this.Home = true;
        this.ShowSkjema = false;
        this.ShowFAQList = false;
        this.ShowAvgSTKFAQList = false;
        this.ShowAnswerList = false;
        this.Registrert = false;
        
    }

    home() {
       
        this.ShowSkjema = false;
        this.ShowFAQList = false;
        this.ShowAvgSTKFAQList = false;
        this.ShowAnswerList = false;
        this.Registrert = false;
    }

    lagreFAQ() {
        var lagretFAQ = new Question();
        lagretFAQ.navn = this.skjema.value.navn;
        lagretFAQ.epost = this.skjema.value.epost;
        lagretFAQ.question = this.skjema.value.question;



        const body: string = JSON.stringify(lagretFAQ);
        const headers = new HttpHeaders({ "Content-Type": "application/json" });

        this._http.post("api/FAQ", body, { headers: headers })
            .subscribe(
                () => {
                    this.hentAlleFAQs();
                    this.ShowSkjema = false;
                    console.log("OK post-api/FAQ");
                },
                error => alert(error)
            );
    };



    like(id: number) {
        this.up(id);
    }

    dislike(id: number) {
        this.down(id)
    }


    Like(id: number) {
        this.opp(id);
    }

    Dislike(id: number) {
        this.ned(id)
    }

    down(id: number) {
        var Likes = new FAQs();

        Likes.dislike = this.stem;

        const body: string = JSON.stringify(Likes);
        const headers = new HttpHeaders({ "Content-Type": "application/json" });

        this._http.put("api/FAQ/" + id, body, { headers: headers })
            .subscribe(
                () => {
                    console.log("dislike post-api/FAQ");
                },
                error => alert(error)
            );
    };


    up(id: number) {
        var Likes = new FAQs();

        Likes.like = this.stem;

        const body: string = JSON.stringify(Likes);
        const headers = new HttpHeaders({ "Content-Type": "application/json" });

        this._http.put("api/FAQ/" + id, body, { headers: headers })
            .subscribe(
                () => {
                    console.log("like post-api/FAQ");
                },
                error => alert(error)
            );
    };

    ned(id: number) {
        var Likes = new FAQs();

        Likes.dislike = this.stem;

        const body: string = JSON.stringify(Likes);
        const headers = new HttpHeaders({ "Content-Type": "application/json" });

        this._http.put("api/FAQ/" + id, body, { headers: headers })
            .subscribe(
                () => {
                    console.log("dislike post-api/FAQ");
                },
                error => alert(error)
            );
    };


    opp(id: number) {
        var Likes = new FAQs();

        Likes.like = this.stem;

        const body: string = JSON.stringify(Likes);
        const headers = new HttpHeaders({ "Content-Type": "application/json" });

        this._http.put("api/FAQ/" + id, body, { headers: headers })
            .subscribe(
                () => {

                    console.log("like post-api/FAQ");
                },
                error => alert(error)
            );
    };
}


