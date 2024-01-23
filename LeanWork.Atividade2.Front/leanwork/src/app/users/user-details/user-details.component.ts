import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})
export class UserDetailsComponent implements OnInit {

  name: any;
  user: any;
  repositories: any;
  loading: boolean = true;

  constructor(private route: ActivatedRoute, private userService: UserService) { }

  async ngOnInit() {
    this.name = this.route.snapshot.paramMap.get('id');
    await this.load();
    await this.getRepositories();
  }

  async load() {
    this.userService.getUser(this.name).subscribe((data) => {
      console.log(data);
      this.user = data;
      this.loading = false;
    });
  }

  async getRepositories() {
    return this.userService.getUserRepositories(this.name).subscribe((data) => {
      console.log(data);
      this.repositories = data;
    });
  }

}
