using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Indentional.Benchmarks
{
    [SimpleJob(RuntimeMoniker.Net50, baseline: true)]
    [SimpleJob(RuntimeMoniker.NetCoreApp30)]
    public class IndentionalBenchmarks
    {

        private readonly string shortString =
                @"
                You tried to do something tricky, but something was not true twice in i row.
                It might be better to do this:

                    DoDoingDone(checkForSomethingTrue: false);
                
                Don't ya think?";

        private readonly string longString =

                @"
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed pharetra odio turpis, at condimentum lectus suscipit vitae. Duis odio lorem, ornare eu mollis quis, ornare non lacus. Vivamus posuere consequat tellus, a eleifend nibh hendrerit et. In hac habitasse platea dictumst. Vivamus blandit felis id risus sollicitudin laoreet. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Morbi ut turpis malesuada, bibendum eros quis, feugiat urna. Suspendisse lectus nisi, convallis vel auctor vel, efficitur ut est. Duis sit amet urna ac augue tristique dapibus. Praesent eget rutrum risus. Mauris nec finibus arcu, semper pellentesque eros. Donec urna nisl, dignissim nec viverra eget, iaculis vitae quam. Maecenas ut blandit arcu. Maecenas et consequat magna, blandit porttitor elit. Etiam id aliquet augue.

                    Vivamus at neque venenatis, accumsan erat nec, pretium lacus. Phasellus ut ante sit amet est imperdiet varius ac sed erat. Sed nec sapien ante. Vestibulum ac elit vitae tortor sollicitudin auctor at id tellus. Fusce a luctus nulla, nec convallis nisl. Sed vel erat a velit mattis sollicitudin a sodales lorem. Vestibulum nec urna sollicitudin, laoreet enim quis, finibus dolor. Proin in aliquet felis. Integer et consequat nulla. Ut eget elit non est pharetra semper in in mauris. Nullam vulputate ullamcorper quam, quis blandit erat pharetra in. Ut quis accumsan sem. Curabitur malesuada imperdiet odio, in blandit turpis egestas sit amet. Sed non tortor sed neque aliquet semper. Cras varius nunc a odio laoreet, non posuere lorem vulputate. Donec non felis quis sem gravida fermentum.

                    Morbi dignissim semper placerat. Nam convallis tincidunt orci ac pharetra. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris volutpat enim eget ipsum aliquam, ut ornare mauris posuere. In auctor magna sit amet orci dictum finibus. Sed fermentum sem id mauris cursus, eu blandit orci condimentum. Phasellus lobortis molestie lacus. Quisque fermentum viverra sapien sit amet viverra.

                    Quisque eleifend sapien id orci hendrerit lobortis non nec ipsum. Vivamus pulvinar turpis fermentum purus mollis, id congue enim eleifend. Donec hendrerit orci eu lacus dignissim venenatis. Quisque sollicitudin tincidunt congue. Etiam dui ligula, pharetra nec neque molestie, vulputate aliquam risus. Nam pulvinar nisi aliquet venenatis finibus. In risus nunc, porta sed mi in, semper scelerisque sem. Maecenas varius faucibus urna eget feugiat. Aenean cursus nibh ut metus faucibus, at tempor ligula varius. Aenean vitae molestie leo. Aliquam eget mollis leo, sed elementum enim.

                        Nam sit amet sagittis mi, scelerisque finibus sapien. Nulla ut maximus est. Etiam vestibulum gravida turpis, vel pharetra libero porta eget. Donec leo elit, venenatis quis ornare at, convallis quis metus. Nunc elementum pharetra ipsum, sed posuere orci pretium a. Donec quis venenatis ex. In hac habitasse platea dictumst. Duis placerat, magna id molestie auctor, tellus arcu sagittis ipsum, eu hendrerit orci felis ut erat. Mauris imperdiet id nisi non consectetur. Donec consectetur, mauris blandit vulputate condimentum, ligula leo ullamcorper nisi, ultricies eleifend enim enim a ex. Curabitur rutrum, nibh non porta placerat, odio neque suscipit mi, vel pretium mauris nisi quis nulla. Phasellus non feugiat dui. Nunc tellus eros, fringilla et dapibus sit amet, hendrerit id turpis. Curabitur congue ut nisl sit amet dignissim. Nam at orci sed dui vehicula elementum ac eu nulla. Nam luctus faucibus sem.

                        Ut sem ex, venenatis in odio non, hendrerit faucibus odio. Praesent mauris elit, euismod vitae quam id, finibus tristique mauris. Integer scelerisque elit libero, vitae scelerisque arcu lacinia in. Vestibulum semper odio vel orci semper, at faucibus eros hendrerit. Praesent ac lobortis sapien. Fusce varius congue lobortis. Pellentesque in elementum leo. Maecenas semper velit quis nulla ultrices rhoncus. Duis et rutrum tellus. Vivamus ultricies magna ac bibendum congue. Aliquam a sapien vitae lorem tristique volutpat. In lobortis consectetur fermentum. Vestibulum porta odio vel ex tincidunt sagittis. Donec elementum iaculis leo, a blandit velit consequat eu.

                    Etiam lobortis sollicitudin lacinia. Pellentesque nec venenatis lorem. Fusce vehicula ex in mi rhoncus egestas. Vestibulum at lorem vitae elit posuere porta. Donec non orci id sapien euismod lacinia quis at est. In dictum nisi id ex fringilla varius non non augue. Morbi tristique justo et libero ullamcorper efficitur. Etiam imperdiet ante non dolor iaculis cursus. Nullam blandit sapien ut commodo accumsan. Suspendisse maximus, est ut tristique suscipit, elit nibh scelerisque augue, eget porttitor erat enim a tellus. Vivamus aliquet maximus turpis, eu imperdiet ipsum lacinia nec. Vivamus non placerat arcu. Suspendisse potenti.

                    Ut pharetra, magna vel dignissim convallis, elit augue bibendum lorem, id maximus tellus turpis at justo. Maecenas pretium eleifend massa. Phasellus nisi diam, ultricies non sodales nec, auctor sagittis nunc. Nulla imperdiet lacus vitae neque tristique, vel eleifend sapien aliquam. Proin ut dui tellus. Morbi ac risus sem. Aenean velit eros, ornare id tincidunt ut, gravida nec libero. Suspendisse potenti. Quisque facilisis ipsum sit amet cursus fermentum. Ut dictum libero lacus, finibus rutrum sapien blandit at. Donec eleifend metus ac velit dapibus, non mattis leo gravida. Phasellus et mattis leo. Mauris sed leo dapibus, posuere augue sit amet, iaculis turpis. Nam tempor cursus hendrerit.

                    Duis orci ligula, placerat vel scelerisque nec, viverra eu quam. Donec ut tempor sem. Duis facilisis semper ligula nec venenatis. Aliquam leo ligula, cursus id fermentum eget, tincidunt sit amet eros. Nunc magna enim, posuere nec magna ac, condimentum suscipit nulla. Cras cursus ex id facilisis varius. Quisque a posuere nulla. Nullam ut efficitur tortor. Maecenas consequat lectus ac lorem condimentum, eu pellentesque augue lobortis. Nunc id ligula accumsan, consectetur mi et, efficitur mauris.

                    Maecenas turpis dui, convallis ac facilisis quis, ultrices at eros. Quisque facilisis blandit semper. Fusce sed ex id nibh pretium maximus a ut leo. Sed at nunc id lacus maximus volutpat ac vitae odio. Aliquam molestie et lacus ut maximus. Praesent venenatis lorem ex. Nam vehicula scelerisque libero ut laoreet. Aenean purus turpis, fringilla quis blandit ut, mollis et neque. Praesent sollicitudin, tellus eu condimentum sollicitudin, mi mi vulputate felis, nec venenatis eros tortor blandit est. Integer tempus dictum nunc in sagittis. Mauris in molestie lectus, vel condimentum augue. Fusce quis auctor erat, a lacinia metus. Ut porta risus orci, sed ultrices enim posuere quis. Suspendisse potenti. Donec bibendum, neque a mattis pretium, est elit viverra urna, vitae fermentum purus ligula id justo.

                    Nunc fermentum, tellus sit amet rutrum gravida, dolor libero tempor augue, sed sollicitudin elit sem sed metus. Nunc est ipsum, aliquam non blandit sit amet, egestas quis augue. Nunc mattis, dolor quis lobortis congue, turpis sapien faucibus nibh, at placerat lacus lectus id risus. Sed nisi lacus, posuere eget sapien nec, congue maximus elit. Nam tempor mollis lacinia. Nunc pretium tortor et risus elementum, ac faucibus urna congue. Ut et tempus nulla, nec malesuada turpis. Quisque ut purus fringilla, molestie diam in, mollis purus. Nam imperdiet gravida neque, sit amet dapibus turpis. Ut porttitor lectus id metus dictum placerat.




                    Vivamus massa metus, consectetur at vehicula id, scelerisque at leo. Fusce ullamcorper nisl at tincidunt gravida. Nunc pellentesque massa at erat dapibus, id lobortis tortor tempus. Maecenas vehicula leo a felis euismod, ut dignissim ex feugiat. Duis et luctus turpis. Nulla a porttitor elit, sed rutrum tortor. Duis egestas purus ut tellus eleifend condimentum. Cras viverra lectus ligula, eu pretium ligula hendrerit et. Aenean nunc magna, elementum at tortor nec, tincidunt dignissim justo. Mauris porta pellentesque quam, eget sagittis leo commodo sed. Etiam suscipit faucibus metus, euismod tempus elit dictum non. In hac habitasse platea dictumst. Integer in leo sit amet tortor finibus cursus mattis auctor diam. Praesent id arcu eu nisl ultrices viverra non ornare massa. Pellentesque semper id tellus ut porta.

                    Aliquam erat volutpat. Aliquam egestas lorem eget pellentesque lacinia. Nunc maximus ante quis justo interdum efficitur. Suspendisse suscipit ligula ut leo gravida, sit amet faucibus mi congue. Ut eros nulla, venenatis in nunc eu, molestie congue ligula. Sed in lacinia dolor. Suspendisse id enim et neque facilisis efficitur. Nunc mauris ipsum, vulputate sed sagittis ac, facilisis in ex. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nunc volutpat facilisis nisi id ultricies. Mauris mattis mollis auctor. Aliquam eros neque, rutrum vitae pharetra a, condimentum ut diam. Mauris aliquam orci neque, sit amet cursus velit elementum id. Maecenas placerat, ex molestie elementum venenatis, ligula eros mattis mauris, vel cursus lectus nunc et turpis.

                    Nam semper turpis nec turpis suscipit, eu lacinia lacus varius. Cras ultrices libero a enim commodo scelerisque. Donec tincidunt sapien erat. Quisque semper euismod urna id pellentesque. Aenean ullamcorper ullamcorper elit, in placerat nibh aliquam non. Duis fringilla ex eget sodales luctus. Proin consequat dignissim velit eget pharetra. Donec feugiat lacus nec vehicula blandit. Suspendisse lobortis massa pellentesque est fermentum, vel scelerisque dui convallis. In imperdiet eros sed nulla ultricies tristique. Curabitur vitae nibh eu neque tincidunt imperdiet. Maecenas vehicula, dolor a sagittis convallis, nibh turpis pellentesque odio, nec consequat nulla nunc vel odio.

                    Cras cursus elementum lorem, et accumsan tellus eleifend in. Morbi ullamcorper dolor gravida, dignissim arcu at, laoreet elit. Fusce blandit libero et elit congue lobortis. Quisque bibendum sapien sed purus gravida tincidunt. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Etiam convallis mauris nec convallis consequat. Maecenas sit amet posuere leo.

                    Aenean efficitur velit id vestibulum vulputate. Nulla facilisi. Donec nisl tortor, auctor a rutrum rhoncus, laoreet nec tortor. Etiam ante neque, egestas at nulla et, dignissim lacinia eros. Nulla imperdiet consequat aliquet. Curabitur ac augue varius, porta urna sit amet, interdum est. Quisque nec interdum est, sit amet varius diam. Integer dictum sapien non nunc laoreet posuere. Praesent ac purus gravida tellus imperdiet ultricies. Integer tellus sapien, elementum sed vehicula vel, imperdiet at orci. Praesent odio ante, placerat ut convallis dapibus, bibendum eu est.

                Phasellus leo nisi, scelerisque non tellus nec, ultrices commodo arcu. Nulla accumsan diam ut dignissim blandit. Ut finibus ut augue vel lacinia. Phasellus a nisl augue. Mauris efficitur lobortis est eu convallis. Duis quam urna, dapibus vitae quam accumsan, congue fermentum magna. Mauris posuere ante mattis libero sagittis cursus. Pellentesque quis risus scelerisque velit luctus mattis eu quis enim. Duis quis elementum augue, vitae dignissim ligula. Mauris pellentesque id erat et vestibulum. Phasellus ultricies sodales accumsan. Nulla gravida erat nec interdum semper. Quisque nec semper ex. Proin ligula lacus, aliquet efficitur rutrum in, vestibulum nec ligula. Curabitur sit amet volutpat augue. Nam pulvinar lobortis tincidunt.

                    Nunc dolor ipsum, viverra eu euismod id, mollis eget ante. Ut in felis quam. Aenean sed velit laoreet, aliquet lacus non, ultricies orci. Quisque a nisl ac enim varius tincidunt a vitae mauris. Sed eget pharetra metus. Donec quam eros, fringilla quis lacus id, malesuada bibendum quam. Suspendisse consequat ligula et elementum fermentum. Maecenas congue eleifend porttitor.

                    Donec tincidunt enim neque, a fringilla nulla elementum eget. Cras eleifend sagittis congue. Sed eget arcu tellus. Pellentesque pulvinar at magna et molestie. Sed ligula metus, pulvinar porttitor egestas non, congue sit amet nunc. Mauris aliquet mi et eros fringilla, eu vulputate urna molestie. Ut cursus suscipit ligula vitae condimentum. Etiam mattis, arcu nec sodales suscipit, enim enim posuere ipsum, non molestie lacus neque nec risus. Nullam interdum laoreet elit sed dictum. Pellentesque commodo et nunc non scelerisque. Duis lobortis, tortor in fringilla mollis, nisl arcu lacinia odio, id tempus quam erat sed velit.

                    Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Morbi eros dui, pretium sit amet sem ac, efficitur suscipit nunc. Quisque sit amet tincidunt massa, sed blandit leo. Curabitur a malesuada arcu, sed vulputate mi. Morbi lacinia, tortor ac malesuada congue, sem massa efficitur leo, ac semper orci ex vel justo. Etiam eget lectus quis quam dignissim pellentesque sed in ligula. Donec quis sollicitudin diam. Pellentesque vitae leo luctus, ornare nulla at, elementum elit. Mauris rutrum, nisl non aliquam elementum, quam quam vestibulum lectus, at blandit ante neque eu libero. Praesent nec diam eleifend, fermentum sapien at, interdum nibh. Aliquam purus nulla, viverra vel gravida quis, congue sed arcu. Nunc sed sem ante. Suspendisse non semper lacus, non rutrum nisi. Donec bibendum felis vitae magna feugiat semper. Proin lacinia arcu vel tristique elementum. Pellentesque ullamcorper commodo dolor, ac posuere nulla bibendum at. ";

        public IndentionalBenchmarks()
        {

        }

        [Benchmark(Baseline = true)]
        public string OriginalShort() => IndentionalOriginal._(shortString);

        [Benchmark]
        public string NoShinyShort() => IndentionalNoMoreShiny._(shortString);

        [Benchmark]
        public string CurrentShort() => Indentional._(shortString);

        [Benchmark]
        public string OriginalLong() => IndentionalOriginal._(longString);

        [Benchmark]
        public string NoShinyLong() => IndentionalNoMoreShiny._(longString);

        [Benchmark]
        public string CurrentLong() => Indentional._(longString);
    }
}
