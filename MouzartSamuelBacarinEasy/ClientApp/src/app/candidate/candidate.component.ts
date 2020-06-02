import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-candidate',
  templateUrl: './candidate.component.html'
})
export class CandidateComponent {
  public _http: HttpClient;
  public _baseUrl: string;
  public form: FormGroup;

  public candidate: Candidate = {
    id: 0,
    name: '',
    email: '',
    phone: '',
    skype: '',
    linkedin: '',
    city: '',
    portfolio: '',
    state: '',
    workSchedule: {
      afternoon: false, business: false, dawn: false, morning: false, night: false, hourlySalaryRequirement: 0, candidate: null, candidateId: null, id: 0
    },
    workLoad: {
      id: 0, onlyWeeKend: false, perDay4To6: false, perDay6To8: false, perDayUpTo4: false, perDayUpTo8: false, candidateId: null, candidate: null
    },
    candidateKnowledges: []
  };

  public workLoad: WorkLoad = null;
  public workSchedule: WorkSchedule = null;
  public knowledges: Knowledge[] = [];


  public name: FormControl = new FormControl('', [Validators.required]);
  public email: FormControl = new FormControl('', [Validators.email]);
  public phone: FormControl = new FormControl('', [Validators.required]);
  public skype: FormControl = new FormControl('', [Validators.required]);
  public linkedin: FormControl = new FormControl('', [Validators.required]);
  public city: FormControl = new FormControl('', [Validators.required]);
  public state: FormControl = new FormControl('', [Validators.required]);
  public portfolio: FormControl = new FormControl('', [Validators.required]);
  public perDayUpTo4: FormControl = new FormControl('');
  public perDay4To6: FormControl = new FormControl('');
  public perDay6To8: FormControl = new FormControl('');
  public perDayUpTo8: FormControl = new FormControl('');
  public onlyWeeKend: FormControl = new FormControl('');
  public morning: FormControl = new FormControl('');
  public afternoon: FormControl = new FormControl('');
  public night: FormControl = new FormControl('');
  public dawn: FormControl = new FormControl('');
  public business: FormControl = new FormControl('');
  public hourlySalaryRequirement: FormControl = new FormControl('', [Validators.required]);

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private formBuilder: FormBuilder, private router: Router, private route: ActivatedRoute) {
    this._baseUrl = baseUrl;
    this._http = http;

    this.form = this.formBuilder.group({
      name: this.name,
      email: this.email,
      phone: this.phone,
      skype: this.skype,
      linkedin: this.linkedin,
      city: this.city,
      state: this.state,
      portfolio: this.portfolio,
      perDayUpTo4: this.perDayUpTo4,
      perDay4To6: this.perDay4To6,
      perDay6To8: this.perDay6To8,
      perDayUpTo8: this.perDayUpTo8,
      onlyWeeKend: this.onlyWeeKend,
      morning: this.morning,
      afternoon: this.afternoon,
      night: this.night,
      dawn: this.dawn,
      business: this.business,
      hourlySalaryRequirement: this.hourlySalaryRequirement
    });

  }

  ngOnInit() {
    let id = this.route.snapshot.paramMap.get('id');
    this.getKnowledge();
    if (id) {
      this._http.get<Candidate>(this._baseUrl + 'api/candidates/' + id).subscribe(result => {
        this.setCandidate(result);
      }, error => console.error(error));
    }
  }

  public setCandidate(candidate: Candidate): void {
    console.log(candidate);
    this.candidate = candidate;
    this.name.setValue(candidate.name);
    this.email.setValue(candidate.email);
    this.phone.setValue(candidate.phone);
    this.skype.setValue(candidate.skype);
    this.linkedin.setValue(candidate.linkedin);
    this.city.setValue(candidate.city);
    this.state.setValue(candidate.state);
    this.portfolio.setValue(candidate.portfolio);
    this.perDayUpTo4.setValue(candidate.workLoad.perDayUpTo4);
    this.perDay4To6.setValue(candidate.workLoad.perDay4To6);
    this.perDay6To8.setValue(candidate.workLoad.perDay6To8);
    this.perDayUpTo8.setValue(candidate.workLoad.perDayUpTo8);
    this.onlyWeeKend.setValue(candidate.workLoad.onlyWeeKend);
    this.morning.setValue(candidate.workSchedule.morning);
    this.afternoon.setValue(candidate.workSchedule.afternoon);
    this.night.setValue(candidate.workSchedule.night);
    this.dawn.setValue(candidate.workSchedule.dawn);
    this.business.setValue(candidate.workSchedule.business);
    this.hourlySalaryRequirement.setValue(candidate.workSchedule.hourlySalaryRequirement);
    if (candidate.candidateKnowledges) {
      for (let item of candidate.candidateKnowledges) {
        (<HTMLInputElement>document.getElementById("knowledge_" + item.knowledgeId + "_" + item.rate)).checked = true;
      }
    }
  }

  public getKnowledge(): void {
    this._http.get<Knowledge[]>(this._baseUrl + 'api/knowledges').subscribe(result => {
      this.knowledges = result;
    }, error => console.error(error));
  }

  public getRadioValue(values: any): number {
    for (var i = 0; i < values.length; i++) {
      if (values[i].checked) {
        return values[i].value;
        break;
      }
    }

  }

  public getCandidateForm(): void {

    let candidateKnowledges: CandidateKnowledges[] = [];

    if (this.candidate.id > 0) {
      for (let item of this.candidate.candidateKnowledges) {
        let candidateKnowledge: CandidateKnowledges = {
          id: item.id,
          candidate: null,
          candidateId: this.candidate.id,
          knowledgeId: item.knowledgeId,
          knowledge: null,
          rate: Number(this.getRadioValue(document.getElementsByName("knowledges_" + item.knowledgeId)))
        };
        candidateKnowledges.push(candidateKnowledge);
      }
    } else {
      for (let item of this.knowledges) {
        let candidateKnowledge: CandidateKnowledges = {
          id: 0,
          candidate: null,
          candidateId: 0,
          knowledgeId: item.id,
          knowledge: null,
          rate: Number(this.getRadioValue(document.getElementsByName("knowledges_" + item.id)))
        };
        candidateKnowledges.push(candidateKnowledge);
      }
    }
    

    this.candidate = {
      id: this.candidate ? this.candidate.id : 0 ,
      name: this.name.value,
      email: this.email.value,
      phone: this.phone.value,
      skype: this.skype.value,
      linkedin: this.linkedin.value,
      city: this.city.value,
      portfolio: this.portfolio.value,
      state: this.state.value,
      candidateKnowledges: candidateKnowledges,
      workSchedule: {
        afternoon: this.afternoon.value ? true : false,
        business: this.business.value ? true : false,
        dawn: this.dawn.value ? true : false,
        morning: this.morning.value ? true : false,
        night: this.night.value ? true : false,
        candidate: null,
        candidateId: this.candidate.id ? this.candidate.id : 0,
        hourlySalaryRequirement: this.hourlySalaryRequirement.value,
        id: this.candidate.workSchedule.id > 0 ? this.candidate.workSchedule.id : 0
      },
      workLoad: {
        id: this.candidate.workLoad.id > 0 ? this.candidate.workLoad.id : 0,
        onlyWeeKend: this.onlyWeeKend.value ? true : false,
        perDay4To6: this.perDay4To6.value ? true : false,
        perDay6To8: this.perDay6To8.value ? true : false,
        perDayUpTo4: this.perDayUpTo4.value ? true : false,
        perDayUpTo8: this.perDayUpTo8.value ? true : false,
        candidateId: this.candidate.id ? this.candidate.id : 0,
        candidate: null
      },
    };
  }

  
  public save(): void {
    this.getCandidateForm();
    console.log(this.candidate);
    this._http.post<Candidate>(this._baseUrl + 'api/candidates', this.candidate).subscribe(result => {
      console.log(this.knowledges, result);
      if (result.id) {
        alert("salvo com sucesso!");
        this.router.navigate(['/candidate/', { id: result.id }]);
      }
    }, error => console.error(error));

  }

  public update(): void {
    this.getCandidateForm();
    console.log(this.candidate);
    this._http.put<Candidate>(this._baseUrl + 'api/candidates/' + this.candidate.id, this.candidate).subscribe(result => {
      console.log(this.knowledges, result);
        alert("salvo com sucesso!");
        this.router.navigate(['/candidate/', { id: result.id }]);
    }, error => console.error(error));

  }

}

