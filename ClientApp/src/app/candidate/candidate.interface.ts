interface Candidate {
  id: number;
  name: string;
  phone: string;
  email: string;
  skype: string;
  linkedin: string;
  city: string;
  state: string;
  portfolio: string;
  workLoad: WorkLoad;
  workSchedule: WorkSchedule;
  candidateKnowledges: CandidateKnowledges[];
}

interface WorkLoad {
  id: number;
  perDayUpTo4: boolean;
  perDay4To6: boolean;
  perDay6To8: boolean;
  perDayUpTo8: boolean;
  onlyWeeKend: boolean;
  candidateId: number;
  candidate: Candidate;
}

interface WorkSchedule {
  id: number;
  morning: boolean;
  afternoon: boolean;
  night: boolean;
  dawn: boolean;
  business: boolean;
  hourlySalaryRequirement: number;
  candidateId: number;
  candidate: Candidate;
}

interface CandidateKnowledges {
  id: number;  
  candidateId: number;
  candidate: Candidate;
  knowledgeId: number;
  knowledge: Knowledge;
  rate: number;
}
interface Knowledge {
  id: number;
  name: string;
  description: string;
}
