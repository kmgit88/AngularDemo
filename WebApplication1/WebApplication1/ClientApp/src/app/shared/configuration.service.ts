import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

export class IServerConfiguration {
  apiAddress: string;
}

@Injectable()
export class ConfigurationService {
  constructor(private http: HttpClient) { }

  public loadConfig(): Observable<IServerConfiguration> {
    return this.http.get<IServerConfiguration>(
      "/api/Configuration/ConfigurationData"
    );
  }
}
