resource "aws_ecrpublic_repository" "snyk" {
  repository_name = var.ecr_name
}

resource "aws_apprunner_service" "snyk_demo_web_app" {
  service_name = "snyk-demo-webapp"

  source_configuration {
    auto_deployments_enabled = false

    image_repository {
      image_configuration {
        port = "80"
      }
      image_identifier      = "${aws_ecrpublic_repository.snyk.repository_uri}:latest"
      image_repository_type = "ECR_PUBLIC"
    }
  }

  tags = {
    Name = "example-apprunner-service"
  }
}