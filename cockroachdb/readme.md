https://dzone.com/articles/3-ways-to-install-cockroachdb-binary-docker-or-kub


# try

```bash
cd try1
kubectl create namespace testdb

kubectl apply -f cockroachdb-statefulset.yaml -n testdb

kubectl get pods -n testdb

kubectl get pv -n testdb


kubectl get job cluster-init -n testdb
kubectl get pods -n testdb
```

# init cluster

```bash
kubectl apply -f cluster-init.yaml -n testdb

kubectl get job cluster-init -n testdb

kubectl get pods -n testdb
```

# access 

Local SQL Client

```bash
kubectl run cockroachdb -it --image=cockroachdb/cockroach:v23.1.11 -n testdb --rm --restart=Never -- sql --insecure --host=cockroachdb-public
```

Web GUI

```bash
kubectl port-forward service/cockroachdb-public 8080 -n testdb
```

Access DB

```bash
kubectl port-forward service/cockroachdb-public 26257 -n testdb
```

Type     Reason            Age                  From               Message
  ----     ------            ----                 ----               -------
  Warning  FailedScheduling  10m                  default-scheduler  0/1 nodes are available: pod has unbound immediate PersistentVolumeClaims. preemption: 0/1 nodes are available: 1 No preemption victims found for incoming pod..
  Normal   Scheduled         10m                  default-scheduler  Successfully assigned testdb/cockroachdb-0 to docker-desktop
  Normal   Pulled            10m                  kubelet            Container image "cockroachdb/cockroach:v23.1.10" already present on machine
  Normal   Created           10m                  kubelet            Created container cockroachdb
  Normal   Started           10m                  kubelet            Started container cockroachdb
  Warning  Unhealthy         15s (x127 over 10m)  kubelet            Readiness probe failed: HTTP probe failed with statuscode: 503


```bash
CREATE USER BOJ WITH PASSWORD 'BOJ';
SQL Error [28P01]: ERROR: setting or updating a password is not supported in insecure mode

CREATE USER BOJ
ได้
```

ALTER ROLE BOJ CREATEDB;
--ALTER ROLE BOJ WITH Superuser; Error ไม่เหมือน postgres

https://www.cockroachlabs.com/docs/stable/alter-user


https://www.cockroachlabs.com/docs/stable/show-databases