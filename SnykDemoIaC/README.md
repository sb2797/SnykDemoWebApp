# Snyk Demo Infrastructure

## About

IaC project to create a basic web hosting infrastructure for the Snyk Demo Web App and test the infrastructure using the *Snyk IaC* tool.

***Disclaimer: These infrastructure configurations are misconfigured on purpose. Use at your own risk.***

## Prerequisites

* terraform version >= 1.1.2
* aws CLI >= 2.4.9
* minikube 
* kubectl

## Test Infrastructure

Execute the following command in the respective folders

    snyk iac test

## Deploy Infrastructure (optional)

### AppRunner

- Go to the *tf-apprunner* folder.

- Specify your own ECR name:

```
    echo 'ecr_name = "<your_ecr_name>"' > terraform.tfvars
```

- Initialize terraform:

```
    terraform init
```

- Create the ECR:

```
tf apply -target aws_ecrpublic_repository.snyk
```
- Push an image to registry 
    - you can use the SnykDemoWebApp Dockerfile
    - go to the AWS ECR console to check out how to push to the public ECR

- Create the app runner

```
tf apply -target aws_apprunner_service.snyk_demo_web_app
```

### k8s
- Go to the k8s folder

```
minikube start
kubectl apply -f ns.yaml
kubectl apply -f manifest.yaml

kubectl get pods -w -n snyk

minikube service snyk-demo-app -n snyk
```