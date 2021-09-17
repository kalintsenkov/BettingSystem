import IGambler from "./gambler.model";

interface IGamblerDetails extends IGambler {
    id: number;
    balance: number;
    totalWins: number;
}

export default IGamblerDetails;