---
marp: true
---

# Dapr

> Make sure Docker desktop is installed & k8s is running

## Install Dapr

> Check [nuget](https://www.nuget.org/packages/Dapr.AspNetCore/) for latest version

```ps1
dotnet add package Dapr.AspNetCore --version 1.5.0
```

---

# Components

Create yaml files for each components

> Create a directory `components` at root level of the repository

---

## State Store

> Create a file `statestore.yaml` with following contents

```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: statestore
spec:
  type: state.redis
  version: v1
  metadata:
    - name: redisHost
      value: localhost:6379
    - name: redisPassword
      value: ""
    - name: actorStateStore
      value: "true"
```

---

## Secrets

> Create a file `localSecretStore.yaml` with following contents

```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: localsecretstore
  namespace: default
spec:
  type: secretstores.local.file
  version: v1
  metadata:
    - name: secretsFile
      value: ./SuperHeroes/secrets.json #path to secrets file
    - name: nestedSeparator
      value: ":"
```
