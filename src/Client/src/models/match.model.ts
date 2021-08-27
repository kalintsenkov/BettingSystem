interface IMatch {
  id: number;
  startDate: string;
  homeTeamName: string;
  awayTeamName: string;
  homeTeamScore?: number;
  awayTeamScore?: number;
}

export default IMatch;
