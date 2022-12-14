variable "environment_name"{
  default = "prod"
}

locals{
    today = timestamp()
    # Terraform 0.12 and later syntax
  required_tags =  {
      username = "alexhole",
      project = "hackathon",
      created_date = "14/12/2022",
      environment_name = "${var.environment_name}"
  }
}