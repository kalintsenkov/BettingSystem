interface IMatch {
  id: number;
  startDate: string;
  homeTeamName: string;
  awayTeamName: string;
  homeTeamScore?: number;
  awayTeamScore?: number;
  homeTeamLogoThumbnailContent: any;
  awayTeamLogoThumbnailContent: any;
}

export default IMatch;
